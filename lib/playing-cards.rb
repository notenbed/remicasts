class Deck < Array

  def self.standard
    deck = Deck.new
    [ 'Club', 'Diamond', 'Heart', 'Spade' ].each do |suit|
      [ 2, 3, 4, 5, 6, 7, 8, 9, 10, 'Jack', 'Queen', 'King', 'Ace' ].each do |rank|
        deck << Card.new(rank, suit)
      end
    end
    deck
  end

end





class Card

  # Club, Heart, Diamond, Spade
  attr_accessor :rank, :suit

  def initialize rank, suit
    @rank  = rank.to_s
    @suit = suit.sub(/s$/, '').capitalize
  end

  def == another_card
    rank == another_card.rank and suit == another_card.suit
  end

  def name
    "#{ rank } of #{ suit }s"
  end

  alias to_s name

  def inspect
    "<Card: \"#{ name }\">"
  end

  def self.parse name
    name = name.to_s.sub(/^the( )?/i, '')

    if name =~ /^(\w+) of (\w+)$/i
      Card.new $1, $2
    elsif name =~ /^(\w+)of(\w+)$/i
      Card.new $1, $2
    end
  end

  class << self
    alias [] parse
  end

end

module CardConstant
  def const_missing name
    if card = Card.parse(name)
      return card
    else
      super
    end
  end
end

Object.send :extend, CardConstant
