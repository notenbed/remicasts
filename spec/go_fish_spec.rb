require File.dirname(__FILE__) + '/spec_helper'

describe GoFish do

  before do
    @game = GoFish::Game.new(2)
    @player1, @player2 = @game.players
  end

  it 'should be able to make a new game given a number of players' do
    game = GoFish::Game.new(2)
    game.players.length.should == 2
    game.players.first.hand.length.should == 9
    game.players.last.hand.length.should  == 9
    game.draw_pile.length.should          == (52 - 9 - 9)
  end

  it 'player should not be able to ask for a rank that is not in their hand'

  it '@player should be able to ask another @player for a rank (Go Fish!)' do
    @game.draw_pile = [The2ofClubs, The3ofClubs]
    @player1.hand   = [The3ofHearts, TheJackOfSpades]
    @player2.hand   = [The4ofHearts, TheJackOfDiamonds]

    @player1.ask_player_for_rank @player2, 3

    @game.draw_pile.should == [The3ofClubs]
    @player1.hand.should   == [The3ofHearts, TheJackOfSpades, The2OfClubs]
    @player2.hand.should   == [The4ofHearts, TheJackOfDiamonds]
  end

  it '@player should be able to ask another @player for a rank (Card is exchanged)' do
    @game.draw_pile = [The2ofClubs, The3ofClubs]
    @player1.hand   = [The3ofHearts, TheJackOfSpades]
    @player2.hand   = [The4ofHearts, TheJackOfDiamonds]

    @player1.ask_player_for_rank @player2, 'Jack'

    @game.draw_pile.should == [The2ofClubs, The3ofClubs]
    @player1.hand.should   == [The3ofHearts, TheJackOfSpades, TheJackOfDiamonds]
    @player2.hand.should   == [The4ofHearts]
  end

  it '@player should be able to ask another @player for a rank (Cards are exchanged)' do
    @game.draw_pile = [The2ofClubs]
    @player1.hand   = [The3ofHearts, TheJackOfSpades]
    @player2.hand   = [The4ofHearts, TheJackOfDiamonds, The3ofClubs, The3ofSpades]

    @player1.ask_player_for_rank @player2, 3

    @game.draw_pile.should == [The2ofClubs]
    @player1.hand.should   == [The3ofHearts, TheJackOfSpades, The3ofClubs, The3ofSpades]
    @player2.hand.should   == [The4ofHearts, TheJackOfDiamonds]
  end

  it 'when a player gets 4 of a particular rank, it forms a book' do
    @game.draw_pile = [The2ofClubs]
    @player1.hand   = [The3ofClubs, The3ofDiamonds, The3ofHearts, The5ofClubs]
    @player2.hand   = [The4ofHearts, TheJackOfDiamonds, The3ofSpades]
    @player1.books.should == []

    @player1.ask_player_for_rank @player2, 3

    @player1.hand.should == [The5ofClubs]
    @player2.hand.should == [The4ofHearts, TheJackOfDiamonds]
    @player1.books.should == ['3']
  end

  it 'player should be able to win!' do
    @game.draw_pile = []
    @player1.hand   = [The3ofClubs, The3ofDiamonds, The3ofHearts]
    @player1.books  = ['Jack', 'Queen']
    @player2.hand   = [The3ofSpades]
    @player2.books  = ['2', '4']

    @game.winner.should be_nil
    @game.should_not be_over

    @player1.ask_player_for_rank @player2, 3

    @player1.hand   = []
    @player1.books  = ['Jack', 'Queen', '3']
    @player2.hand   = []
    @player2.books  = ['2', '4']

    @game.should be_over
    @game.winner.should == @player1

    # just to make sure that the winner is based off of the books

    @player1.books  = ['Jack', 'Queen', '3']
    @player2.books  = ['2', '4', '5', '7']
    @game.winner.should == @player2
  end

end
