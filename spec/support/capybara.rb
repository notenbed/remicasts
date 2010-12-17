require 'selenium-webdriver'

### This will be available in the next release of capybara if you require 'capybara/rspec'
require 'capybara'
require 'capybara/dsl'
RSpec.configure do |config|
  config.include Capybara
  config.after do
    Capybara.reset_sessions!
    Capybara.use_default_driver
  end
  config.before do
    Capybara.current_driver = Capybara.javascript_driver if example.metadata[:js]
    Capybara.current_driver = example.metadata[:driver] if example.metadata[:driver]
  end
end
###

Capybara.default_selector  = :css
Capybara.current_driver    = :rack_test
Capybara.javascript_driver = :selenium

Capybara.register_driver :selenium do |app|
  browser = ENV['BROWSER'] ? ENV['BROWSER'].downcase.to_sym : :firefox

  if browser == :htmlunit
    capabilities = Selenium::WebDriver::Remote::Capabilities.htmlunit
    capabilities.javascript_enabled = true
    Capybara::Driver::Selenium.new app, :browser => :remote, :desired_capabilities => capabilities
  else
    Capybara::Driver::Selenium.new app, :browser => browser
  end
end

# Usage:
#   fill_in_fields :foo => 'bar'                                # fill_in 'foo', :with => 'bar'
#   fill_in_fields :user, :name => 'bob'                        # fill_in 'user_name', :with => 'bob'
#   fill_in_fields :contact, :address, :street => '6 cedar rd'  # fill_in 'contact_address_street_, :with => '6 cedar rd'
def fill_in_fields *args
  hash   = args.pop
  prefix = ''
  while args.any?
    prefix += args.shift.to_s + "_" 
  end 
  hash.each do |key, value|
    fill_in "#{prefix}#{key}", :with => value
  end
end
