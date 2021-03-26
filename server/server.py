import asyncio

from utils.getche import getche


class Server:

    async def echo_server(self, reader, writer):
        while True:
            char = getche()
            writer.write(bytes(char, encoding="UTF-8"))
            await writer.drain()

    async def serve(self, host, port):
        socket = await asyncio.start_server(self.echo_server, host, port)
        await socket.serve_forever()

    def run(self):
        asyncio.run(self.serve("", 8765))


if __name__ == '__main__':
    server = Server()
    server.run()
