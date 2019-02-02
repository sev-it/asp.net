export const mergeStyles = (firstStyle, secondStyle) => {
  const assignedStyles =
    firstStyle && firstStyle
      ? Object.assign({}, firstStyle, secondStyle)
      : firstStyle
        ? firstStyle
        : secondStyle
          ? secondStyle
          : {};
  return assignedStyles;
};