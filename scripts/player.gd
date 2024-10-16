extends CharacterBody2D

@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D

const ANIMATION_IDLE = "idle"
const ANIMATION_RUN = "run"
const SPEED = 150
const JUMP_VELOCITY = -400.0


func _physics_process(_delta: float) -> void:
	var direction_x_axis := Input.get_axis("left_axis", "right_axis")
	var direction_y_axis := Input.get_axis("up_axis", "down_axis")
	
	if direction_x_axis or direction_y_axis:
		velocity.x = direction_x_axis * SPEED
		velocity.y = direction_y_axis * SPEED
		animated_sprite_2d.flip_h = direction_x_axis < 0  # Simplification du flip
		if animated_sprite_2d.animation != ANIMATION_RUN:
			animated_sprite_2d.animation = ANIMATION_RUN
	else:
		velocity.x = move_toward(velocity.x, 0, SPEED)
		velocity.y = move_toward(velocity.y, 0, SPEED)
		if animated_sprite_2d.animation != ANIMATION_IDLE:
			animated_sprite_2d.animation = ANIMATION_IDLE

	move_and_slide()
	
	
func save():
	var save_dict = {
		"filename" : get_scene_file_path(),
		"parent" : get_parent().get_path(),
		"pos_x" : position.x, # Vector2 is not supported by JSON
		"pos_y" : position.y,
	}
	return save_dict	
