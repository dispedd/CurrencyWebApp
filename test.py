from flask import Flask, jsonify, request

app = Flask(__name__)

# Data dummy (sebagai database sementara)
users = [
    {"id": 1, "name": "Fikri Hikmat", "email": "fikri@example.com"},
    {"id": 2, "name": "Ayu Lestari", "email": "ayu@example.com"}
]

# Endpoint GET semua user
@app.route('/users', methods=['GET'])
def get_users():
    return jsonify(users)

# Endpoint GET user by ID
@app.route('/users/<int:user_id>', methods=['GET'])
def get_user(user_id):
    user = next((u for u in users if u["id"] == user_id), None)
    return jsonify(user) if user else ("User not found", 404)

# Endpoint POST untuk tambah user baru
@app.route('/users', methods=['POST'])
def create_user():
    new_user = request.get_json()
    new_user['id'] = users[-1]['id'] + 1 if users else 1
    users.append(new_user)
    return jsonify(new_user), 201

# Endpoint PUT untuk update user
@app.route('/users/<int:user_id>', methods=['PUT'])
def update_user(user_id):
    user = next((u for u in users if u["id"] == user_id), None)
    if user is None:
        return ("User not found", 404)
    data = request.get_json()
    user.update(data)
    return jsonify(user)

# Endpoint DELETE user
@app.route('/users/<int:user_id>', methods=['DELETE'])
def delete_user(user_id):
    global users
    users = [u for u in users if u["id"] != user_id]
    return jsonify({"message": "User deleted successfully"})

# Run server
if __name__ == '__main__':
    app.run(debug=True)
