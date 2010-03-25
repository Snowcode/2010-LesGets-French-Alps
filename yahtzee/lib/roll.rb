class Roll
  def initialize(dice)
    @results = Hash.new(0)

    dice.each do |die|
      @results[die.roll] += 1
    end
  end

  def number_of(result)
    @results[result]
  end

  def display
    output = "Your roll\n"
    sorted_results = @results.to_a.sort { |a, b| a[0] <=> b[0]}
    sorted_results.each do |pair|
      output += "#{pair[1]} -> #{pair[0]}\n"
    end
    output
  end
end