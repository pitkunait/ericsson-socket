import asyncio
import logging

from utils.getche import getche

logger = logging.getLogger(__name__)


class Server:

    async def socket_function(self, reader, writer):
        logger.info("STARTING SOCKET FUNCTION")
        while True:
            char = getche()
            writer.write(bytes(char, encoding="UTF-8"))
            await writer.drain()

    async def serve(self, host, port):
        socket = await asyncio.start_server(self.socket_function, host, port)
        await socket.serve_forever()

    def run(self):
        asyncio.run(self.serve("", 8765))


if __name__ == '__main__':
    server = Server()
    server.run()
