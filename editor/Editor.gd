extends TextEdit


signal command_parsed


# Called when the node enters the scene tree for the first time.
func _ready() -> void:
	pass # Replace with function body.


# Called every frame. 'delta' is the elapsed time since the previous frame.
func _process(_delta: float) -> void:
	if Input.is_action_just_released('submit_code'):
		print_debug('starting tokenization')
		for token in self.text.split(' '):
			print_debug('token:' + token)
			var word: String = token.to_lower()
			match word:
				'up':
					emit_signal('command_parsed', 'up')
				'down':
					emit_signal('command_parsed', 'down')
				'left':
					emit_signal('command_parsed', 'left')
				'right':
					emit_signal('command_parsed', 'right')

func _on_TextEdit_text_changed() -> void:
	print_debug(self.text)
