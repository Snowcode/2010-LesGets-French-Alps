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

  def add_to_crappy_plastic_tray(die, turn)
    if @dice_in_tray.length == 5
      raise "Already 5 dice in tray..."
    end
    @dice_in_tray << DiceInTray.new(die, turn)

  end

  def remove_from_tray(index)
    @dice_in_tray.delete_at(index)
  end
  
  def reset_turn(turn)
    @dice_in_tray = @dice_in_tray.select { |x| x.turn_added != turn }
  end

  def display()
    if @dice_in_tray.empty?
       puts "You have nothing in your crappy plastic tray!"
    else
      sep = ""
      print "In the crappy plastic tray, you have: "
      @dice_in_tray.each_with_index do |die_in_tray, index|
         print sep + die_in_tray.die_value.to_s

        sep = ", "
      end
      puts ""
    end
  end

  def number_of(result)
     @dice_in_tray.select { |x| x.die_value == result }.length
  end

  def number_of(result, turn)
     @dice_in_tray.select { |x| (x.die_value == result) and (x.turn_added==turn) }.length
  end

  def [](index)
    @dice_in_tray[index]
  end

  def length()
    @dice_in_tray.length
  end
end

class DiceInTray

  attr_reader :die_value, :turn_added

  def initialize(die_value, turn_added)
    @die_value = die_value
    @turn_added = turn_added
  end
end