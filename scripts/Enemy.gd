extends KinematicBody2D
var motion = Vector2()

func _ready():
	pass # Replace with function body.

func _physics_process(delta):
	var Player = get_parent().get_node("player")
	
	position += (Player.position - position)/50
	look_at(Player.position)
	
	move_and_collide(motion)
