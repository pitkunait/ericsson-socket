buildserver:
	docker build -t stdin-server server
runserver:
	docker run -it --name stdin-server -p 8765:8765 stdin-server
buildclient:
	docker build -t stdin-client client
runclient:
	docker run -it --link stdin-server stdin-client