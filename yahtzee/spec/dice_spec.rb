require "rspec"
require "lib/dice.rb"

describe Dice do

  it "should return the Nth die" do
    dice = Dice.a_set_of 5

    dice[3].class.should == Die
    dice[5].should be_nil
  end
end