module GoFish

  class Player
    attr_accessor :game, :hand, :books

    def hand= value
      @hand = value.to_deck
    end

    def initialize game
      @game  = game
      @books = []
    end

    def ask_player_for_rank another_player, rank
      matching_cards = another_player.hand.select {|card| card.rank == rank.to_s }

      if matching_cards.empty?
        hand << game.draw_pile.draw
      else
        matching_cards.each do |card|
          hand << another_player.hand.draw(card)
        end
      end
      
      check_for_books!
    end

  private

    def check_for_books!
      possible_books = {}
      hand.each do |card|
        possible_books[card.rank] ||= []
        possible_books[card.rank] << card
      end
      possible_books.each do |rank, cards|
        if cards.length == 4
          books << rank
          cards.each {|card| hand.delete card }
        end
      end
    end
  end

  class Game
    attr_accessor :players, :draw_pile

    def draw_pile= value
      @draw_pile = value.to_deck
    end

    def initialize number_of_players
      @draw_pile = Deck.standard.shuffle!
      @players = []
      number_of_players.times do
        player = Player.new(self)
        player.hand = draw_pile.draw(9)
        @players << player
      end
    end

    def winner
      if over?
        players.sort_by {|player| player.books.length }.last
      end
    end

    def over?
      return false unless draw_pile.empty?
      players.each do |player|
        return false unless player.hand.empty?
      end
      return true
    end
  end

end
