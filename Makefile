buildserver:
	docker build -t stdin-server server
runserver:
	docker run -it -p 8765:8765 stdin-server
