buildserver:
	docker build -t stdin-server server
runserver:
	docker run -it --network stdin-network -p 8765:8765 stdin-server
buildclient:
	docker build -t stdin-client client
runclient:
	docker run -it --network stdin-network stdin-client
createnetwork:
	docker network create stdin-network
make build:
	make createnetwork && make buildserver && make buildclient