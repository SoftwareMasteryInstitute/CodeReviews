

PACMAN SIMULATOR

About Simulator

The library simulate a Pacman moving on in a square grid without any obstractions. To start the simulater, Pacman has to be placed on the grid.
However, all the movements until Pacman is placed on the grid surface are ignored. Pacman is free to roam around the grid and is programmed to prevent from falling off the 
grid. Valid movements that cause Pacman to fall off the grid are ignored but further movements are still allowed. Library read inputs
as commands line inputs.

Sample commands should be in following form:


PLACE X,Y,DIRECTION
MOVE
LEFT
RIGHT
REPORT

PLACE : will put the Pacman on the grid in position X,Y and facing NORTH, SOUTH, EAST or WEST. (0,0) can be considered as the SOUTH WEST corner
and (4,4) as the NORTH EAST corner. The first valid command to the Pacman is a PLACE command. After that, any sequence of commands may be issued, 
in any order, including another PLACE command. The library should discard all commands in the sequence until a valid PLACE command has been 
executed. The PLACE command should be discarded if it places the Pacman outside of the grid surface.

MOVE : will move the Pacman one unit forward in the direction it is currently facing.

LEFT and RIGHT : will rotate the Pacman 90 degrees in the specified direction without changing the position.

REPORT : will announce the X,Y and orientation of the Pacman.

A Pacman that is not on the grid can choose to ignore the MOVE, LEFT, RIGHT and REPORT commands.

Example Input and Output:


PLACE 0,0,NORTH
MOVE
REPORT

Output: 0,1,NORTH

PLACE 0,0,NORTH
LEFT
REPORT

Output: 0,0,WEST

PLACE 1,2,EAST
MOVE
MOVE
LEFT
MOVE
REPORT

Output: 3,3,NORTH

Running the solution:

Library is written on Visual Studio 2019 community edition. Application is a .Net Core 2.2 console application. PacmanLibrary 
contains all the functionalities of the Pacman. Simulater inside the Pacman_Simulator is used to pass the given command to the Pacman. When you run the console application, commands will be exected automatically and output will be displayed on the console window.

Running Unit Tests:

Unit tests written using NUnit (version 3.12) framework. 

Unit tests are written to cover all the functionalities of the Pacman.
