# Chess Time

## Intro

The project consists in a chess in a console app made in .net Core. The Data is kept in memory.

Chess is a game of strategy and tactics for two players, played on an 8x8 chequered board. Although chess sets come in many varieties and colours, the traditional colours are white and black. In this case black will be replaced by red, due to the black background of the console.


| The Game - in the console App |![ezgif com-crop (4)](https://user-images.githubusercontent.com/55409351/77004281-bc91d800-6956-11ea-841d-997f31cca78a.gif)|
| -------- | -------- |
## How to Play
### The Goal
The aim of the game is to trap your opponent's king, which is called Checkmate. 

### The army
Each player has an army consisting of:
* A king (K); 
* A queen (Q); 
* Two rooks (R); 
* Two bishops (B); 
* Two knights (H); 
* And eight pawns (P).

### Turns and to capture pieces
Each turn, you must move one piece to a new dash. The player with the white pieces goes first, and after that the players take it in turns to move a piece. There are no dice in chess - every piece has its own way of moving, and it's up to you which one you want to move. Each piece also has the ability to capture, an enemy piece. To do this, you simply move your piece or pawn onto the square occupied by the enemy piece, and it will remove from the board and add into the Black or White Array.

### Movements
The moves of each are restricted by showing to the play where he can go with a specific member of the army:
* The king moves one square in any direction. The king also has a special move called castling that involves also moving a rook.
* A rook can move any number of squares along a rank or file, but cannot leap over other pieces. Along with the king, a rook is involved during the king's castling move.
* A bishop can move any number of squares diagonally, but cannot leap over other pieces.
The queen combines the power of a rook and bishop and can move any number of squares along a rank, file, or diagonal, but cannot leap over other pieces.
* A knight moves to any of the closest squares that are not on the same rank, file, or diagonal. (Thus the move forms an "L"-shape: two squares vertically and one square horizontally, or two squares horizontally and one square vertically.) The knight is the only piece that can leap over other pieces.
* A pawn can move forward to the unoccupied square immediately in front of it on the same file, or on its first move it can advance two squares along the same file, provided both squares are unoccupied; or the pawn can capture an opponent's piece on a square diagonally in front of it on an adjacent file, by moving to that square. A pawn has two special moves: 
  * the *en passant* capture - when a pawn makes a two-step advance from its starting position and there is an opponent's pawn on a square next to the destination square on an adjacent file, then the opponent's pawn can capture it *en passant*, moving to the square the pawn passed over.
  * and promotion - where, after the pawn advances to the eight rank, it becomes a Queen.

#### Check
When a king is under immediate attack by one or two of the opponent's pieces

## Download and Play!

* To download: $ git clone https://github.com/JonathanPalma-code/Chess-Game
* To use: You should be able to interact with the application by clicking on Chess.exe. The file is located in: Chess/bin/Debug/netcoreapp3.1/

