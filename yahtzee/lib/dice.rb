require File.expand_path("lib/die")

class Dice
  include Enumerable

  def each(&block)
    yield block
  end

  def self.a_set_of(n)
    Dice.new(n)
  end

  def initialize(n)
    @dice = [Die.new]*n
  end

  def roll
    Roll.new(@dice)  
  end

  def [](index)
    @dice[index]
  end
end