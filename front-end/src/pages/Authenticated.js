import { Card, CardActionArea, CardContent, CardMedia, Typography } from '@mui/material';
import React from 'react';
import { signOut } from '../utils/auth';
import pic1 from "../assets/library1.jpg"
import pic2 from "../assets/library2.jpg"

export default function Authenticated({ user }) {
  return (
    <div className="welcomeText text-center mt-5">
      <div className="cardText">
        <Card sx={{ maxWidth: 345 }}>
          <CardActionArea>
            <CardMedia
              component="img"
              height="140"
              image={pic1}
              alt="img1"
              />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                About Us
              </Typography>
              <Typography variant="body2" color="text.secondary">
                We made The Lore Store in 2022 to be able to share our love of literature and various medias to the world, as well as making an easy to use and streamlined online market to make purchasing your favorite books easier!
              </Typography>
            </CardContent>
          </CardActionArea>
        </Card>
        <Card sx={{ maxWidth: 345 }}>
          <CardActionArea>
            <CardMedia
              component="img"
              height="140"
              image={pic2}
              alt="img1"
              />
            <CardContent>
              <Typography gutterBottom variant="h5" component="div">
                Info
              </Typography>
              <Typography variant="body2" color="text.secondary">
                The Lore Store was developed to get rid of the hassle of bloated online markets that take too long to get you to the product that you truly want. Using our site, you can sort by various genres as well as search for specific books that you may be interested in. 
              </Typography>
            </CardContent>
          </CardActionArea>
        </Card>
      </div>
      <div className="lookAboveText">
      <Typography className="mt-5" variant="h4">
          Please take a look above to access our search options, card, and profile!
        </Typography>
      </div>
    </div>
  );
}
