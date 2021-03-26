FROM python

WORKDIR /app

COPY . .
RUN pip install -r requirements.txt
EXPOSE 8765
ENTRYPOINT ["python", "server_socket.py"]