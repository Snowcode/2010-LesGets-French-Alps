require File.expand_path("lib/die")

#This is a comment

class PlasticTray
  include Enumerable

  def initialize
    @dice_in_tray = []
  end

  def each(&block)
    yield block
  end

  def add_to_tray(die)
    if @dice_in_tray.length == 5
      raise "Already 5 dice in tray..."
    end
    @dice_in_tray << die
  end

  def [](index)
    @dice[index]
  end
end