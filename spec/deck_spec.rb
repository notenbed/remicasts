require File.dirname(__FILE__) + '/spec_helper'

describe Deck do

  it 'can get an empty deck' do
    deck = Deck.new
    deck.length.should == 0
    deck.should be_empty
  end

  it 'can get a standard deck of 52 cards' do
    deck = Deck.standard
    deck.length.should == 52

    deck.first.should == The2OfClubs
    deck[12].should   == TheAceOfClubs
    deck[13].should   == The2OfDiamonds
    deck[26].should   == The2OfHearts
    deck[39].should   == The2OfSpades 
    deck.last.should  == TheAceOfSpades
  end

  it 'can shuffle a deck'

  it 'can draw from a deck'

  it 'can draw a particular number of cards from a deck'

  it 'can draw from the bottom of a deck'

  it 'can draw a particular card from a deck'

  it 'can deal cards into piles'

end
