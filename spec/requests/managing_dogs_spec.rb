require 'spec_helper'

describe 'Managing Dogs' do

  it 'should be able to add a dog' do
    Dog.count.should == 0
    visit root_path
    click_link 'Dogs'
    click_link 'Add a new dog'

    fill_in_fields :dog,
      :name  => 'Rover',
      :breed => 'Golden Retriever'
    click_button 'Add Dog'

    # Dog.count.should == 1
    Dog.first.name.should  == 'Rover'
    Dog.first.breed.should == 'Golden Retriever'
  end

  it 'should be able to add a dog with javascript', :js => true do
    Dog.count.should == 0
    visit root_path
    click_link 'Dogs'
    click_link 'Add a new dog'

    fill_in_fields :dog,
      :name  => 'Rover',
      :breed => 'Golden Retriever'
    click_button 'Add Dog'

    # Dog.count.should == 1
    Dog.first.name.should  == 'Rover'
    Dog.first.breed.should == 'Golden Retriever'
  end

  it 'can correct validation errors'
  # ... 

end
