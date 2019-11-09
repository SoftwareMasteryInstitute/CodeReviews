module ToyRobot
  class Table
    def initialize(width, length)
      @width = width
      @length = length
    end

    def valid_location? (x, y)
      (0...@width).cover?(x) &&
      (0...@length).cover?(y)
    end
  end
end