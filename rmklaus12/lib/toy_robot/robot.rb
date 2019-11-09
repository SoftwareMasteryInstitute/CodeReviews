module ToyRobot
  class Robot
    DIRECTIONS = %w[NORTH EAST SOUTH WEST]
    attr_reader :x, :y, :facing

    def initialize(x = 0, y = 0, facing = 'NORTH')
      @x = x
      @y = y
      @facing = facing
    end

    def move_east
      @x += 1
    end

    def move_west
      @x -= 1
    end

    def move_north
      @y += 1
    end

    def move_south
      @y -= 1
    end

    def move
      case @facing
      when 'NORTH' then move_north
      when 'SOUTH' then move_south
      when 'EAST' then move_east
      when 'WEST' then move_west
      end
    end

    def turn_left
      turn(:left)
    end

    def turn_right
      turn(:right)
    end

    def report
      {
          x: x,
          y: y,
          facing: facing
      }
    end

    def next_move
      case @facing
      when 'NORTH' then [@x, @y + 1]
      when 'SOUTH' then [@x, @y - 1]
      when 'EAST' then [@x + 1, @y]
      when 'WEST' then [@x - 1, @y]
      end
    end

    private

    def turn(turn_direction)
      index = DIRECTIONS.index(@facing)
      rotations = turn_amount(turn_direction)
      @facing = DIRECTIONS.rotate(rotations)[index]
    end

    def turn_amount(turn_direction)
      case turn_direction
      when :right then 1
      when :left then -1
      end
    end
  end
end
