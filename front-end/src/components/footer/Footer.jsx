import { Box, Grid } from "@mui/material";
import { Container } from "react-bootstrap";
import { Link } from "react-router-dom";
import './Footer.css';

const Footer = () => {
    return (
        <>
        <Box>
            <Container>
                <Grid className="footerContainer" container spacing={1}>
                    <Grid className="footerLinks" item xs={12} sm={10}>
                        <Box className="link-control" borderBottom={1}></Box>
                        <div className="links">
                        <Box className="insideLinks">
                            <Link to="/" className="smallLink" color="inherit">
                                Home
                            </Link>
                        </Box>
                        <Box className="insideLinks">
                            <Link to="/advancedSearch" className="smallLink" color="inherit">
                                Search
                            </Link>
                        </Box>
                        <Box className="insideLinks">
                            <Link to="/cart" className="smallLink" color="inherit">
                                Cart
                            </Link>
                        </Box>
                        <Box className="insideLinks">
                            <Link to="/profile" className="smallLink" color="inherit">
                                Profile
                            </Link>
                        </Box>
                        <Box className="smallLink">
                            <p>© The Lore Store</p>
                        </Box>
                        </div>
                    </Grid>
                </Grid>
            </Container>
        </Box>
        </>
    )
}

export default Footer;