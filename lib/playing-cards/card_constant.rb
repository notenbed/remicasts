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
