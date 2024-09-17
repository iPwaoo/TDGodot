extends CharacterBody2D


const SPEED = 150
const JUMP_VELOCITY = -400.0


func _physics_process(delta: float) -> void:

	var direction_x_axis := Input.get_axis("ui_left", "ui_right")
	if direction_x_axis:
		velocity.x = direction_x_axis * SPEED
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		
		
	var direction_y_axis := -Input.get_axis("ui_down","ui_up")
	if direction_y_axis:
		velocity.y = direction_y_axis * SPEED
	else:
		velocity.y = move_toward(velocity.y, 0, SPEED)

	move_and_slide()
