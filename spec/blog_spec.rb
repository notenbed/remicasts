require 'rubygems'
require 'rack/test'
require File.dirname(__FILE__) + '/../blog'

describe 'Blog' do
  include Rack::Test::Methods

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

end
