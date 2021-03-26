import asyncio

import websockets

from utils.getche import getche


class WSServer:

    async def read_stdin(self, websocket, path):
        while True:
            char = getche()
            try:
                await websocket.send(char)
            except Exception:
                await asyncio.sleep(0)

    def run(self):

        start_server = websockets.serve(self.read_stdin, "", 8765)
        asyncio.get_event_loop().run_until_complete(start_server)
        asyncio.get_event_loop().run_forever()


if __name__ == '__main__':
    server = WSServer()
    server.run()
