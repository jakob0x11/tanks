extends ColorRect

export var squares = 8;

# Called when the node enters the scene tree for the first time.
func _ready():
	var board_size: Vector2 = get_viewport_rect().size
	var square_size = board_size.x / squares
	var cur_line = square_size
	for square in squares:
		var line = Line2D.new()
#		line.points()

