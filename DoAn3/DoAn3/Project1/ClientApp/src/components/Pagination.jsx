import React from "react";
import { useEffect } from "react";
import styled from "styled-components";

const ListButton = styled.div`
    display: flex;
    align-items: center;
    justify-content: center;
    margin-top: 30px;
`;
const Button = styled.button`
    background-color: white;
    border: none;
    font-size: 16px;
    padding: 10px 15px;
    margin-right: 10px;
    cursor: pointer;
    border-radius: 4px;
`;
const ButtonActive = styled(Button)`
    background-color: #fa9494;
    color: white;
`;

const Pagination = ({
    totalPosts,
    postsPerPage,
    setCurrentPage,
    currentPage,
}) => {
    let pages = [];
    for (let i = 1; i <= Math.ceil(totalPosts / postsPerPage); i++) {
        pages.push(i);
    }
    return (
        <ListButton>
            {pages.map((page, index) => {
                if (page === currentPage) {
                    return (
                        <ButtonActive
                            key={index}
                            onClick={() => setCurrentPage(page)}
                        >
                            {page}
                        </ButtonActive>
                    );
                } else {
                    return (
                        <Button
                            key={index}
                            onClick={() => setCurrentPage(page)}
                            className={page === currentPage ? "active" : ""}
                        >
                            {page}
                        </Button>
                    );
                }
            })}
        </ListButton>
    );
};

export default Pagination;
