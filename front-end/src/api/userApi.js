const UserApi = {
  UserExists: async (uid, token) => {
    const res = await fetch(`https://localhost:7294/api/UserAuth/${uid}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    });
    const res2 = await res.json();
    return res2;
  },
  UpdateUser: async (id, updatedUser, token) => {
    await fetch(`https://localhost:7294/api/User/${id}`, {
      method: 'PUT',
      headers: {
        'Content-type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
      body: JSON.stringify(updatedUser),
    });
  },
};

export default UserApi;