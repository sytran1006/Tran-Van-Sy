import { css } from "styled-components";

export const mobile = (props) => {
  return css`
    @media only screen and (max-width: 380px) {
      ${props}
    }
  `;
};

export const tablet = (props) => {
  return css`
    @media (min-width: 740px) and (max-width: 1023px) {
      ${props}
    }
  `;
};
