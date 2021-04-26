FROM node:14.16.1-alpine AS base

WORKDIR /src
COPY *.json ./

FROM base as dev
RUN npm install
COPY . ./
CMD ["npm", "start"]