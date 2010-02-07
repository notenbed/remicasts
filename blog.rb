require 'rubygems'
require 'sinatra'
require File.dirname(__FILE__) + '/post'

Post.dir = File.dirname(__FILE__) + '/posts'

get '/' do
  @posts = Post.all
  haml :index
end

get '/:name' do
  @post = Post[ params[:name] ]
  if @post
    haml :post
  else
    status 404
  end
end
