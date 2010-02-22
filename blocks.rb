require 'rubygems'
require 'spec'

class Array
  def format &block
    map do |float|
      sprintf block.call(float), float
    end
  end
end

class Routes
  attr_accessor :resources

  def initialize
    @resources = []
  end

  def resources resource_name = nil
    if resource_name
      @resources << resource_name
    else
      @resources
    end
  end

  # Routes.draw do |map|
  #   map.resources :dog
  # end
  #
  # Routes.draw do
  #   resources :dog
  # end
  def self.draw &block
    routes = Routes.new
    if block.arity >= 1
      block.call(routes)
    else
      routes.instance_eval &block
    end
    routes
  end
end

describe 'Our block stuff' do

  it 'should work' do
    floats  = [12.3567654, 45.34567, 32.5478309, 234.34905]
    desired = ['12.36', '45.35', '32.55', '234.35']
    floats.map    {|float| sprintf '%.2f', float }.should == desired
    floats.format {|float| '%.2f' }.should == desired
  end

  it 'routing without block' do
    routes = Routes.new
    routes.resources.should be_empty # []

    routes.resources :dogs
    routes.resources.should == [:dogs]

    routes.resources :toys
    routes.resources.should == [:dogs, :toys]
  end

  it 'routing with variable' do
    routes = Routes.draw do |map|
      map.resources :dogs
      map.resources :toys
    end

    routes.resources.should == [:dogs, :toys]
  end

  it 'routing without variable' do
    routes = Routes.draw do
      resources :dogs
      resources :toys
    end

    routes.resources.should == [:dogs, :toys]
  end

end
