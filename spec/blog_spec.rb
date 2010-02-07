require 'rubygems'
require 'rack/test'
require 'webrat'
require File.dirname(__FILE__) + '/../blog'

Webrat.configure do |config|
  config.mode = :rack
end

describe 'Blog' do
  include Rack::Test::Methods
  include Webrat::Methods
  include Webrat::Matchers

  def app
    Sinatra::Application
  end

  it 'should display the names of all posts on the home page' do
    Post.dir = File.dirname(__FILE__) + '/posts0'
    get '/'
    last_response.body.should_not include('foo')

    Post.dir = File.dirname(__FILE__) + '/posts1'
    get '/'
    last_response.body.should include('foo')
  end

  it 'should display the HTML of blogs posts' do
    Post.dir = File.dirname(__FILE__) + '/posts3'

    get '/hello'
    last_response.body.should include('<p><em>How</em> <strong>goes</strong>')
  end

  it 'should should the body of a post when you visit /[post name]' do
    Post.dir = File.dirname(__FILE__) + '/posts0'
    get '/foo'
    last_response.status.should == 404
    last_response.body.should   == ''

    Post.dir = File.dirname(__FILE__) + '/posts1'
    get '/foo'
    last_response.status.should == 200
    last_response.body.should include('Hello from foo!')
  end

  it 'should be able to navigate to blog posts from the home page' do
    Post.dir = File.dirname(__FILE__) + '/posts1'

    get '/'
    click_link 'foo'
    last_response.body.should include('Hello from foo!')
  end

end
