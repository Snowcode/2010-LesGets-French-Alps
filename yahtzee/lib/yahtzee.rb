module Yahtzee
  def self.game
    require 'dice'
    require 'roll'
    require 'plastic_tray'
    require 'scorecard'
    
    dice = Dice.a_set_of 5
    roll = dice.roll
    scorecard = Scorecard.new();

    puts roll.display
    puts "Which dice do you want to keep?"
    input_text = ""
    turn = 1
    my_plastic_tray = PlasticTray.new()

    begin
      input_text = gets.strip!.downcase

      case
      when (r = input_text[/^remove (\d)$/,1	]) != nil
        if( my_plastic_tray.remove(r) != nil )
       	   puts r + " has been removed from your crappy plastic tray"
       	   my_plastic_tray.display();

       	else
           puts "There is no die with value " + r + " in your crappy plastic tray"
        end
      when input_text == "reset"
        my_plastic_tray.reset_turn(turn)
        puts "All dice from this turn have been removed..."
        my_plastic_tray.display()
      when input_text == ""
        my_plastic_tray.display()
      when input_text == "show"
        my_plastic_tray.display()
      when input_text == "next"
        turn += 1
        if turn >= 4
          #check for 5 dice, then do scoring
          if( my_plastic_tray.length < 5 )
            puts "You must have five dice before you can finish this turn"
          else
            puts "You're ready to score.  Display the scorecard and do that thing"
            exit
          end
        else
          roll = dice.roll
          puts roll.display
          puts "Which dice do you want to keep?"
        end
      when input_text == "scorecard"
      	scorecard.display();
      when (r = input_text[/^score (\d)$/,1	]) != nil
      	scorecard.score( my_plastic_tray, r )
      	scorecard.display();
      else
        die_to_keep = input_text.to_i
        if die_to_keep < 1 or die_to_keep > 6
          puts "To keep a die input a number between 1 and 6"
        elsif (roll.number_of die_to_keep) == 0
          puts "There is no die of that number in this roll"
        elsif (roll.number_of die_to_keep) <= (my_plastic_tray.number_of(die_to_keep, turn))
          puts "You've already added all of your #{die_to_keep}s to your crappy plastic tray"
        else
          my_plastic_tray.add_to_crappy_plastic_tray(die_to_keep, turn)
          my_plastic_tray.display()
          puts "You kept #{die_to_keep}"
        end
      end

    end while input_text != "done"

  end

end