require "rspec"
require "lib/roll.rb"
require "lib/dice.rb"

describe Roll do
  before(:each) do
    @dice = Dice.a_set_of 5
  end

  it "should tell me how many of each digit have been rolled" do
    mock_result_of_dice(@dice, [1, 1, 3, 2, 5])

    roll = @dice.roll

    roll.number_of(1).should == 2
    roll.number_of(5).should == 1
  end

  it "should visualise the roll" do
    mock_result_of_dice(@dice, [5,2,3,2,2])

    roll = @dice.roll

    roll.display.should == "Your roll\n" +
                           "3 -> 2\n" +
                           "1 -> 3\n" +
                           "1 -> 5\n"
  end

  def mock_result_of_dice(dice, digits)
    digits.each_with_index do |digit, index|
      dice[index].should_receive(:roll).and_return(digit)
    end
  end
end