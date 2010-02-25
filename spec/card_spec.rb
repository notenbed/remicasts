require File.dirname(__FILE__) + '/spec_helper'

describe Card do

  # Rank ...  2, Jack
  # Suite ... Club, Spade

  it 'has a rank and a suit' do
    card = Card.new 2, 'Spade'
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'should be able to initialize a card with a pluralized suit' do
    card = Card.new 2, 'Spades'
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can easily get a card by name' do
    card = Card.parse('2 of Spades')
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can more easily get a card by name' do
    card = Card['2 of Spades']
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can parse a card name with or without "The"' do
    card = Card['The 2 of Spades']
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can parse a card name with or without "The"' do
    card = Card['The2ofSpades']
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can parse a card name with or without "The"' do
    card = Card['The2OfSpades']
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can parse a card regardless of the casing of the suit' do
    card = Card.new 2, 'spades'
    card.rank.should  == '2'
    card.suit.should == 'Spade'

    card2 = Card.new 2, 'sPaDes'
    card2.rank.should  == '2'
    card2.suit.should == 'Spade'
  end

  it 'can parse a card name from a constant' do
    card = The2ofSpades
    card.rank.should  == '2'
    card.suit.should == 'Spade'
  end

  it 'can compare cards' do
    card1 = The2OfSpades
    card2 = Card.new(2, 'Spades')

    card1.object_id.should_not == card2.object_id

    card1.should == card2
  end

  it 'has a name' do
    The2OfSpades.name.should == '2 of Spades'
    The2OfSpades.to_s.should == '2 of Spades'
    The2OfSpades.inspect.should == '<Card: "2 of Spades">'
  end

end
