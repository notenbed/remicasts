class Dog < ActiveRecord::Base
  validates_presence_of :name, :breed
  validates_uniqueness_of :name
end
