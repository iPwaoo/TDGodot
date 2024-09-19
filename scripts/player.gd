extends CharacterBody2D

@onready var animated_sprite_2d: AnimatedSprite2D = $AnimatedSprite2D

const ANIMATION_IDLE = "idle"
const ANIMATION_RUN = "run"
const SPEED = 150
const JUMP_VELOCITY = -400.0


func _physics_process(delta: float) -> void:
	var direction_x_axis := Input.get_axis("left_axis", "right_axis")
	var direction_y_axis := -Input.get_axis("down_axis", "up_axis")

	
	# Vérifie si le joueur se déplace
	if direction_x_axis or direction_y_axis:
		velocity.x = direction_x_axis * SPEED
		velocity.y = direction_y_axis * SPEED
		# Si le joueur bouge, on lance l'animation "run"
		if animated_sprite_2d.animation != ANIMATION_RUN:
			animated_sprite_2d.animation = ANIMATION_RUN
	else:
		velocity.x = 0 #move_toward(velocity.x, 0, SPEED)
		velocity.y = 0 #move_toward(velocity.y, 0, SPEED)
		# Si aucune direction n'est active, on joue l'animation "idle"
		if animated_sprite_2d.animation != ANIMATION_IDLE:
			animated_sprite_2d.animation = ANIMATION_IDLE
	move_and_slide()
