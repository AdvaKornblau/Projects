import { CSSProperties } from "react";
import styles from "./WordCycler.module.css";

interface WordCyclerProps {
  words: string[];
  currentIndex: number;
  onClick: () => void;
  className?: string;
  }

function WordCycler({ words, currentIndex, onClick, className }: WordCyclerProps) {
  return (
    <div
      className={`${styles.wordCycler} ${className || ""}`}
      onClick={onClick}
      role="button"
      tabIndex={0}
      aria-label="Click to cycle through word options"
   >
    {words.map((word, index) => (
      <div
        key={index}
        className={`${styles.word} ${index === currentIndex ? styles.selected : ""}`}
        style={{'--scale': index === currentIndex ? '1.1' : '1',
            '--opacity': index === currentIndex ? '1' : '0.4',
          } as CSSProperties}
        >
            {word}
        </div>
    ))}
    </div>
);
}

export default WordCycler;