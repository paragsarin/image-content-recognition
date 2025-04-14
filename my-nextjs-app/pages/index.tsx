import React from 'react';
import Link from 'next/link';

const Home: React.FC = () => {
    return (
        <div>
            <h1>Welcome to the Image Upload App</h1>
            <p>Upload an image and ask a question about it.</p>
            <Link legacyBehavior href="/upload">
                <a>Go to Upload Page</a>
            </Link>
        </div>
    );
};

export default Home;