import firebase from 'firebase/app';
import 'firebase/auth';

const signIn = async () => {
  const provider = new firebase.auth.GoogleAuthProvider();
  const userLogin = await firebase.auth().signInWithPopup(provider);
  console.log(userLogin);
  await fetch(`https://localhost:7294/api/UserAuth/${userLogin.user.uid}`, {
    headers: {
      'Content-Type': 'application/json',
      Authorization: `Bearer ${userLogin.user.Aa}`,
    },
  });
};

const signOut = () => {
  firebase.auth().signOut();
};

export { signIn, signOut };
