module Yahtzee
  def self.game
    require 'dice'
    require 'roll'

    dice = Dice.a_set_of 5
    roll = dice.roll

    puts roll.display
    puts "Which dice do you want to keep?"
    input_text = ""

    begin
      input_text = gets.strip!

      if input_text == "reset"
        #...
      end
      die_to_keep = input_text.to_i
      if die_to_keep < 1 or die_to_keep > 6
        puts "To keep a die input a number between 1 and 6"
      else
        #...
        puts "You kept #{die_to_keep}"
      end
    end while input_text != "done"

  end
end