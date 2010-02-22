%w( rubygems sinatra jadof ).each {|lib| require lib }
include JADOF
Page.dir = 'cms'

get '/' do
  @pages = Page.all
  haml :pages
end

get '/*' do
  @page = Page.get params[:splat].first
  haml :page
end

__END__

@@ pages

%ul
  - for page in @pages
    %li
      %a{ :href => "/#{ page.to_param }" }= page

@@ page

%h1= @page

= @page.to_html
