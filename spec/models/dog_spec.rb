require 'spec_helper'

describe Dog do

  it 'requires unique name' do
    Dog.gen(:name => nil     ).should_not be_valid
    Dog.gen(:name => ''      ).should_not be_valid
    Dog.gen(:name => 'Rover' ).should     be_valid
    Dog.gen(:name => 'Rover' ).should_not be_valid
    Dog.gen(:name => 'Snoopy').should     be_valid
  end

  it 'requires breed' do
    Dog.gen(:breed => nil               ).should_not be_valid
    Dog.gen(:breed => ''                ).should_not be_valid
    Dog.gen(:breed => 'Golden Retriever').should     be_valid
  end

end
