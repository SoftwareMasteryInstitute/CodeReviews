puts "Welcome to Toy Robot!"
puts "~~~~~~~~~~~~~~~~~~~~~"

puts ""
puts "What would you like to do?"
puts "1 - Place robot on table"
puts "2 - Move robot one space"
puts "3 - Rotate robot left"
puts "4 - Rotate robot right"
puts "5 - Report robot's position"
puts "6 - stop"

action = gets.chomp.to_i

case action
when 1 then puts "place robot"
when 2 then # move robot
when 3 then # rotate robot left
when 4 then # rotate robot right
when 5 then # report robot position and direction facing
when 6 then stop
else
    puts "Please enter an option between 1 and 6"
end
