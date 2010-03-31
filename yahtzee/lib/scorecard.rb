require File.expand_path("lib/die")
require 'plastic_tray'


#This is a comment

class Scorecard
  def initialize
	 @upper = UpperSection.new();
	 @lower = LowerSection.new();
	 
  end
  
  def score( plastic_tray, r )
  
		if( (n = r[/[123456]/]) != nil)
			@upper.Score(plastic_tray, n)
		end
	end

	def display()
		@upper.display();
		@lower.display();
	end
end

class UpperSection
	def initialize
		@scores = []
		@scores[1..6] = [nil, nil, nil, nil, nil, nil]
		puts @scores[3]
		bonus = 0
	end
	
	def Score( plastic_tray, num )
		num = num.to_i
		if( @scores[num] != nil)
			raise "You have already scored this box"
		end 
		newScore = num * plastic_tray.number_of!(num)
		@scores[num] = newScore
	end
	
	def display()
		total = 0
		(1..6).each do |i|
			total = (!@scores[i].nil? && total+@scores[i]) || total
			puts "Count and only add #{i}s: " + @scores[i].to_s
		end
		puts "Bonus (63 points or more) 0"
		puts "Total for upper section #{total}"
	end
end

class LowerSection
	def initialize
	end
	
	def display()
	end
end