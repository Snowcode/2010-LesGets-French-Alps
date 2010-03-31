require "rspec"
require "lib/die"

describe Die do

  it "should return a random number between 1 and 6" do
    die = Die.new
    die.should_receive(:rand).with(6).and_return(0)

    die.roll.should == 1
  end
end