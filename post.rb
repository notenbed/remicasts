class Post

  class << self
    # The directory to load posts from
    attr_accessor :dir
  end

  def self.all
    Dir[File.join(dir, '**')].map do |filename|
      Post.new(filename)
    end
  end

  def self.first
    all.first
  end

  def self.[] name
    Post.all.find {|post| post.name == name }
  end

  attr_accessor :name, :body

  def initialize filename
    @name = File.basename filename
    @body = File.read(filename).strip
  end

end
