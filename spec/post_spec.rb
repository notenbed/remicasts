require File.dirname(__FILE__) + '/../post'

describe Post do

  it 'should be able to load all posts' do
    Post.dir = File.dirname(__FILE__) + '/posts1'
    Post.all.length.should == 1
    Post.first.name.should == 'foo'

    Post.dir = File.dirname(__FILE__) + '/posts2'
    Post.all.length.should == 1
    Post.first.name.should == 'bar'
  end

  it 'should be able to get the body of a post' do
    Post.dir = File.dirname(__FILE__) + '/posts1'

    Post.first.name.should == 'foo'
    Post.first.body.should == 'Hello from foo!'
  end

  it 'should be able to get a post by name via ["name"]' do
    Post.dir = File.dirname(__FILE__) + '/posts1'
    
    Post['hello'].should be_nil
    Post['foo'].name.should == 'foo'
    Post['foo'].body.should == 'Hello from foo!'
  end

  it 'should markdownify the body of a post' do
    Post.dir = File.dirname(__FILE__) + '/posts3'
    
    Post['hello'].body.should == '*How* __goes__ `it`?'
    Post['hello'].html.should == '<p><em>How</em> <strong>goes</strong> <code>it</code>?</p>'
  end

end
