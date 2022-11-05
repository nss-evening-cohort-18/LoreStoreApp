const UserApi = {
  UserExists: async (uid, token) => {
    await fetch(`https://localhost:7294/api/UserAuth/${uid}`, {
      headers: {
        'Content-Type': 'application/json',
        Authorization: `Bearer ${token}`,
      },
    });
  },
};

export default UserApi;
