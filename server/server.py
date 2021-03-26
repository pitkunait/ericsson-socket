import asyncio

from utils.getche import getche


class Server:

    async def socket_function(self, reader, writer):
        while True:
            writer.write(bytes(getche(), encoding="UTF-8"))
            await writer.drain()

    async def serve(self, host, port):
        socket = await asyncio.start_server(self.socket_function, host, port)
        return await socket.serve_forever()

    def run(self, host, port):
        loop = asyncio.get_event_loop()
        loop.run_until_complete(server.serve(host, port))
        loop.run_forever()


if __name__ == '__main__':
    server = Server()
    server.run("", 8765)
